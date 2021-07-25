import {Component, Inject} from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { News } from 'src/models/Entities';


@Component({
    selector: 'dialog-overview-example-dialog',
    templateUrl: 'NewsModale.componenet.html',
    styleUrls: ['./NewsModale.component.css'] 
  })
  export class NewsModalecomponenet {
    slected="0"
    constructor(
      public dialogRef: MatDialogRef<NewsModalecomponenet>,
      @Inject(MAT_DIALOG_DATA) public data: News) {
          console.log(data)
      }
  
    onNoClick(): void {
      this.dialogRef.close();
    }
  
  }