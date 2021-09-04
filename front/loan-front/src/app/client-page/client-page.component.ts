import { Component, OnInit } from '@angular/core';
import { Client } from '../Models/client';
import { ClientService } from '../services/client.service';

@Component({
  selector: 'app-client-page',
  templateUrl: './client-page.component.html',
  styleUrls: ['./client-page.component.css']
})
export class ClientPageComponent implements OnInit {
  clients: Client[] = [];
  constructor(private clientService: ClientService) { }

  ngOnInit() {
    this.GetClients();
  }

  private GetClients() {
    this.clientService.getClients()
      .then((data: Client[]) => {
        this.clients = data;
      });
  }
}
