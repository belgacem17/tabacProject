import {Component, Inject} from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { Question } from 'src/models/Entities';


@Component({
    selector: 'dialog-overview-example-dialog',
    templateUrl: 'QuestionModale.componenet.html',
    styleUrls: ['./QuestionModale.component.css'] 
  })
  export class QuestionModalecomponenet {
    slected="0"
    constructor(
      public dialogRef: MatDialogRef<QuestionModalecomponenet>,
      @Inject(MAT_DIALOG_DATA) public data: Question) {
          console.log(data)
      }
  
    onNoClick(): void {
      this.dialogRef.close();
    }
  
  }