import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
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

@Component({
  selector: 'app-login',
  imports: [ButtonModule, CheckboxModule, InputTextModule, PasswordModule, FormsModule, RouterModule, RippleModule, AppFloatingConfigurator, ToastModule, MessageModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
  providers: [MessageService]
})
export class LoginComponent implements OnInit {
  
  email: string = '';

  password: string = '';

  checked: boolean = false;
  loggedIn: boolean = false;
  submitted = false;
  loading = false;

  constructor(
    private router: Router,
    private authService: AuthService,
    private messageService: MessageService
  ){

  }

  ngOnInit() {
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

  onSubmit(){
    this.authService
        .login(this.email, this.password,this.checked)
        .subscribe( {
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
        });
  }

}
