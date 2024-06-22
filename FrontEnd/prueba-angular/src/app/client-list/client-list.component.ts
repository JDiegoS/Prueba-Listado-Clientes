import { ClientService } from './../services/client.service';
import { Component, OnInit } from '@angular/core';
import {ClientDetail} from './../interfaces/client-detail.interface'
import { Router } from '@angular/router';

@Component({
  selector: 'app-client-list',
  templateUrl: './client-list.component.html',
  styleUrls: ['./client-list.component.css']
})
export class ClientListComponent implements OnInit {

  constructor(private clientService: ClientService, private router: Router) { }

  clients: ClientDetail[] = [];

  ngOnInit(): void {
    this.clientService.getClients().subscribe(data => {
      this.clients = data;
    })
  }

  AddClient(){
    this.router.navigateByUrl('/add-client');
  }

  EditClient(){
    this.router.navigateByUrl('/edit-client');
    
  }

  DeleteClient(){
    this.router.navigateByUrl('/delete-client');
    
  }

}
