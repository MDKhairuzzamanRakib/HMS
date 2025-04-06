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
import { UserRegister } from '../models/user-register';
import { FloatLabel } from 'primeng/floatlabel';
import { CommonModule } from '@angular/common';
import { DatePicker } from 'primeng/datepicker';

@Component({
  selector: 'app-register',
  imports: [ButtonModule, CheckboxModule, InputTextModule, PasswordModule, FormsModule, RouterModule, RippleModule, AppFloatingConfigurator, ToastModule, MessageModule, FloatLabel, CommonModule, DatePicker],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss',
  providers: [MessageService]
})
export class RegisterComponent implements OnInit {
  
  loggedIn: boolean = false;
  submitted = false;
  loading = false;

  userRegister : UserRegister = new UserRegister();

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
    
  }

}
