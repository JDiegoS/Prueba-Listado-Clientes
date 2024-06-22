import { Component, OnInit } from '@angular/core';
import { FormsModule }   from '@angular/forms';
import { ClientService } from './../services/client.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-client',
  templateUrl: './add-client.component.html',
  styleUrls: ['./add-client.component.css']
})
export class AddClientComponent implements OnInit {

  constructor(private clientService: ClientService, private router: Router) { }

  ngOnInit(): void {
  }

  userDetails = {
    name: '',
    location: '',
    phone: '',
    comments: ''
  };

  submitForm(form: any): void {
    this.clientService.addClient(this.userDetails.name, this.userDetails.location, this.userDetails.phone, this.userDetails.comments).subscribe( data => {
      this.router.navigateByUrl('/client-list');

    })
  }

}
