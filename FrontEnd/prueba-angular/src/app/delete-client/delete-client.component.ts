import { Component, OnInit } from '@angular/core';
import { FormsModule }   from '@angular/forms';
import { ClientService } from './../services/client.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-delete-client',
  templateUrl: './delete-client.component.html',
  styleUrls: ['./delete-client.component.css']
})
export class DeleteClientComponent implements OnInit {

  constructor(private clientService: ClientService, private router: Router) { }

  ngOnInit(): void {
  }

  userDetails = {
    name: '',
  };

  submitForm(form: any): void {
    this.clientService.DeleteClient(this.userDetails.name).subscribe( data => {
      this.router.navigateByUrl('/client-list');

    })
  }

}
