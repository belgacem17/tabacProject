import {Component, Inject} from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { Reclamation } from 'src/models/Entities';


@Component({
    selector: 'ReclamationModale',
    templateUrl: 'ReclamationModale.componenet.html',
    styleUrls: ['./ReclamationModale.component.css'] 
  })
  export class ReclamationModalecomponenet {
    slected="0"
    constructor(
      public dialogRef: MatDialogRef<ReclamationModalecomponenet>,
      @Inject(MAT_DIALOG_DATA) public data: Reclamation) {
          console.log(data)
      }
  
    onNoClick(): void {
      this.dialogRef.close();
    }
  
  } 