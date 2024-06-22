import { Component, OnInit } from '@angular/core';
import { FormsModule }   from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private userService: UserService, private router: Router) { }

  ngOnInit(): void {
  }

  userDetails = {
    username: '',
    password: ''
  };

  submitForm(form: any): void {
    this.userService.getUser(this.userDetails.username, this.userDetails.password).subscribe( data => {
      if (data){
        this.router.navigateByUrl('/client-list');

      }

    })
  }

}
