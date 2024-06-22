import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClientListComponent } from './client-list/client-list.component';
import { AddClientComponent } from './add-client/add-client.component';
import { EditClientComponent } from './edit-client/edit-client.component';
import { AppComponent } from './app.component';
import { DeleteClientComponent } from './delete-client/delete-client.component';
import { LoginComponent } from './login/login.component';

const routes: Routes = [
  {
    path: '',
    component: AppComponent,
    //canActivate: [AuthGuard],
    children: [
      {path: 'login', component: LoginComponent},
      {path: 'client-list', component: ClientListComponent},
      {path: 'add-client', component: AddClientComponent},
      {path: 'edit-client', component: EditClientComponent},
      {path: 'delete-client', component: DeleteClientComponent},
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
