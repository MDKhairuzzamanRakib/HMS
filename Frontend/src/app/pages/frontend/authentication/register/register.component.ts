import { Component, OnInit } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { ButtonModule } from 'primeng/button';
import { CheckboxModule } from 'primeng/checkbox';
import { InputTextModule } from 'primeng/inputtext';
import { PasswordModule } from 'primeng/password';
import { Ripple, RippleModule } from 'primeng/ripple';
import { Toast, ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';
import { MessageModule } from 'primeng/message';
import { AppFloatingConfigurator } from '../../../../layout/component/app.floatingconfigurator';
import { AuthService } from '../../../../core/services/auth.service';
import { UserRegister } from '../models/user-register';
import { FloatLabel } from 'primeng/floatlabel';
import { CommonModule } from '@angular/common';
import { DatePicker } from 'primeng/datepicker';
import { Subscription } from 'rxjs';
import { SelectedModel } from '../../../../core/models/selectedModel';
import { Select } from 'primeng/select';
import { GenderService } from '../../basic-setup/services/gender.service';

@Component({
  selector: 'app-register',
  imports: [ButtonModule, CheckboxModule, InputTextModule, PasswordModule, FormsModule, RouterModule, RippleModule, AppFloatingConfigurator, ToastModule, MessageModule, FloatLabel, CommonModule, DatePicker, Select],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss',
  providers: [MessageService, GenderService]
})
export class RegisterComponent implements OnInit {
  subscription: Subscription[]=[]
  loggedIn: boolean = false;
  submitted = false;
  loading = false;
  genders : SelectedModel[] = [];
  selectedGender : any;
  selectedDate : any;

  userRegister : UserRegister = new UserRegister();

  constructor(
    private router: Router,
    private authService: AuthService,
    private messageService: MessageService,
    public genderService : GenderService,
  ){

  }

  ngOnInit() {
    this.getSelectedGenders();
    if(this.authService.currentUserValue!=null&&this.authService.currentUserValue.token!=null) {
      this.authService.verifyToken(this.authService.currentUserValue.token).subscribe({
        next: response => {
          if(response.success) {
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
      this.subscription.forEach(subs=>subs.unsubscribe());
    }
}

getSelectedGenders(){
    this.subscription.push(
        this.genderService.getSelectedGender().subscribe((res) => {
            this.genders = res;
      })
    )
}


  onSubmit(form: NgForm){
    if (form.valid) {
      
    } else {
      Object.values(form.controls).forEach(control => {
        control.markAsTouched();
      });
    }
  }

}
