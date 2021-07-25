import { Component, OnInit } from '@angular/core';
import { AlertModalecomponenet } from "../modales/AlertModale.componenet";
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { typeUserConnect } from 'src/models/Entities';

@Component({
  selector: 'app-dashboard-acceuil',
  templateUrl: './dashboard-acceuil.component.html',
  styleUrls: ['./dashboard-acceuil.component.css']
})
export class DashboardAcceuilComponent implements OnInit {
   typeUserConnect= new typeUserConnect();
  constructor(public dialog: MatDialog) { }

  ngOnInit(): void {
  }
  scrollToElement(element): void { 
     element.scrollIntoView({behavior: "smooth", inline: "nearest"});
  }

 
  openDialog(type): void {  
    this.typeUserConnect.typeConnect=type;
    const dialogRef = this.dialog.open(AlertModalecomponenet, {
      width: '30%',
      panelClass: 'custom-modalbox' ,
      data: {typeConnect: this.typeUserConnect.typeConnect,   
      }
      
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(result); 
    });
  }
}
