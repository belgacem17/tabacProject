import { Component, OnInit } from "@angular/core"; 
import {MatDialog } from '@angular/material/dialog';
import { User } from 'src/models/Entities';
import { UserModalecomponenet } from "../modales/UserModale.componenet";
import { UserServicesService } from "src/app/services/userServices/user-services.service";
 
@Component({
  selector: "app-user", 
  templateUrl: "user.component.html",
   styleUrls: ['./user.component.css'] 
})
export class UserComponent implements OnInit {
  user:User=new User;
  listUser :User[]=[]; 

  constructor(public dialog: MatDialog,public userServicesService : UserServicesService ) {

   
  }
 
  ngOnInit( ) {

    this.getUsers()
  }
  openDialog(): void {  
    this.user.email='belgacem@gmail.com'
    const dialogRef = this.dialog.open(UserModalecomponenet, {
      width: '100%',
      panelClass: 'custom-modalbox',
      data: {
        userId: this.user.userId, 
        firstName: this.user.firstName, 
        email: this.user.email,
        lastName: this.user.lastName,
        userType: this.user.userType,
        password: this.user.password,
        mobile: this.user.mobile,
      }
      
    });

    dialogRef.afterClosed().subscribe(result => {
      this.getUsers()
    });
  }

  getUsers()
  {
    this.userServicesService.getUsers().subscribe((data: User[]) => {
      console.log(data)
     this.listUser = data;
    }); 
  }
  getuserbyId(){
    this.userServicesService.getUsers().subscribe((data: User[]) => {
      console.log(data)
     this.listUser = data;
    }); 
  }
  createUser(){
    this.userServicesService.createUser(this.user).subscribe((data: User[]) => {
      
     this.listUser = data;
    }); 
  }
  deleteUser(id){
    this.userServicesService.deleteUser(id).subscribe(() => {
      for( var i = 0; i < this.listUser.length; i++){ 
    
        if ( this.listUser[i].userId === id) { 
    
          this.listUser.splice(i, 1); 
          break;
        }
    
    } 
    }); 
  }
  UpdateUser(Userupdate,i){
    this.user.userId=Userupdate.userId, 
    this.user.firstName=Userupdate.firstName
    this.user.email=Userupdate.email
    this.user.lastName=Userupdate.lastName
    this.user.userType=Userupdate.userType
    this.user.password=Userupdate.password
    this.user.mobile=Userupdate.mobile
    const dialogRef = this.dialog.open(UserModalecomponenet, {
      width: '100%',
      panelClass: 'custom-modalbox',
      data: {
        userId: this.user.userId, 
        firstName: this.user.firstName, 
        email: this.user.email,
        lastName: this.user.lastName,
        userType: this.user.userType,
        password: this.user.password,
        mobile: this.user.mobile,
      }
      
    });

    dialogRef.afterClosed().subscribe(result => {
      this.getUsers()
    });
  
  }
}
