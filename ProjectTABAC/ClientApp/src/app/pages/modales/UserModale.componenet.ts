import {Component, Inject} from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { User } from 'src/models/Entities';
import { UserServicesService } from "src/app/services/userServices/user-services.service";
import { Validators, FormBuilder, FormGroup, FormControl } from '@angular/forms';


@Component({
    selector: 'UserModale',
    templateUrl: 'UserModale.componenet.html',
    styleUrls: ['./UserModale.component.css'] 
  })
  export class UserModalecomponenet {
    userForm: FormGroup;
    usertype:any=0
    constructor(
      public dialogRef: MatDialogRef<UserModalecomponenet>,
      @Inject(MAT_DIALOG_DATA) public data: User,public userServicesService : UserServicesService, private formBuilder: FormBuilder) {
        this.usertype= String(this.data.userType)
        // this.userForm = this.formBuilder.group({ 
        //   firstName: [data.firstName, Validators.required],
        //   lastName: [data.lastName, Validators.required],
        //   email: [data.email, Validators.required], 
        //   userType: [data.userType, Validators.required], 
        //   password: [data.password, Validators.required], 
        //   mobile: [data.mobile, Validators.required], 
        // }  
        // );
      }
  
    onNoClick(): void {
      
    console.log(this.data)
    if(this.data.userId==0)
    {
      this.createUser()
    }else{
      this.update()
    }
     
     this.dialogRef.close();
    }
    createUser(){
  
      this.userServicesService.createUser(this.data).subscribe((data: User[]) => {
       
        console.log(this.data)
        
       //this.listUser = data;
      }); 
    }
    usertypeSelect($event){
      this.data.userType= parseInt($event.target.value)
    }
    update(){
      this.userServicesService.updateUser(this.data.userId,this.data).subscribe((data: User) => {
        console.log(data) 
      });
    }
  }