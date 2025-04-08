import { Component, OnInit } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { ButtonModule } from 'primeng/button';
import { CheckboxModule } from 'primeng/checkbox';
import { InputTextModule } from 'primeng/inputtext';
import { PasswordModule } from 'primeng/password';
import { Toast, ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';
import { MessageModule } from 'primeng/message';
import { AppFloatingConfigurator } from '../../../../layout/component/app.floatingconfigurator';
import { AuthService } from '../../../../core/services/auth.service';
import { UserRegister } from '../models/user-register';
import { FloatLabel } from 'primeng/floatlabel';
import { CommonModule } from '@angular/common';
import { DatePicker } from 'primeng/datepicker';
import { from, Subscription } from 'rxjs';
import { SelectedModel } from '../../../../core/models/selectedModel';
import { Select } from 'primeng/select';
import { GenderService } from '../../basic-setup/services/gender.service';

@Component({
  selector: 'app-register',
  imports: [ButtonModule, CheckboxModule, InputTextModule, PasswordModule, FormsModule, RouterModule,  AppFloatingConfigurator, Toast, MessageModule, FloatLabel, CommonModule, DatePicker, Select],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss',
  providers: [MessageService, GenderService]
})
export class RegisterComponent implements OnInit {
  subscription: Subscription[] = []
  loggedIn: boolean = false;
  submitted = false;
  loading = false;
  genders: SelectedModel[] = [];
  selectedGender: any;
  selectedDate: any;

  userRegister: UserRegister = new UserRegister();

  constructor(
    private router: Router,
    private authService: AuthService,
    private messageService: MessageService,
    public genderService: GenderService,
  ) {

  }

  ngOnInit() {
    this.getSelectedGenders();
    if (this.authService.currentUserValue != null && this.authService.currentUserValue.token != null) {
      this.authService.verifyToken(this.authService.currentUserValue.token).subscribe({
        next: response => {
          if (response.success) {
            this.loggedIn = true;
            this.router.navigate([""])
          } else {
            this.loggedIn = false;
            this.authService.logout();
          }
        }
      })
    }
  }

  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.forEach(subs => subs.unsubscribe());
    }
  }

  getSelectedGenders() {
    this.subscription.push(
      this.genderService.getSelectedGender().subscribe((res) => {
        this.genders = res;
      })
    )
  }


  onSubmit(form: NgForm) {
    if (form.valid) {
      this.userRegister.genderId = form.value.gender.id;
      this.userRegister.userName = form.value.email;
      this.userRegister.dateOfBirth = form.value.dateOfBirth.toISOString().split('T')[0];
      this.subscription.push(
        this.authService.register(this.userRegister).subscribe((res: any) => {
          if (res.success) {
            this.subscription.push(
              this.authService
                .login(this.userRegister.userName, this.userRegister.password, true)
                .subscribe({
                  next: res => {
                    if (res) {
                      const role = this.authService.currentUserValue.role;
                      this.router.navigate(['']);
                      this.loading = false;
                      this.messageService.add({ severity: 'success', summary: 'Success', detail: 'Login Successfull' });
                    } else {
                      this.submitted = false;
                      this.loading = false;
                    }
                  },
                  error: err => {
                    this.submitted = false;
                    this.loading = false;
                  }
                })
            )
          }
          else {
            this.messageService.add({ severity: 'error', summary: 'Failed', detail: res.message });
          }
        })
      )
    } else {
      Object.values(form.controls).forEach(control => {
        control.markAsTouched();
      });
    }
  }

}
