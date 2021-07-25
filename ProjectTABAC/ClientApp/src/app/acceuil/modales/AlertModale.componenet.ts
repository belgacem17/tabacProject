import {Component, Inject} from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { QuestionModalecomponenet } from "../../pages/modales/questionModale/QuestionModale.componenet";
import { NewsModalecomponenet } from "../../pages/modales/NewModale/NewsModale.componenet";
import { ReclamationModalecomponenet } from "../../pages/modales/ReclamationModale/ReclamationModale.componenet";
import { Question,News,Reclamation } from 'src/models/Entities';
import { typeUserConnect } from 'src/models/Entities';
import { Router } from '@angular/router';


@Component({
    selector: 'dialog-overview-example-dialog',
    templateUrl: 'AlertModale.componenet.html',
    styleUrls: ['./AlertModale.component.css'] 
  })
  export class AlertModalecomponenet {
    slected="0"
    Question= new Question();
    News= new News();
    Reclamation= new Reclamation();
    constructor(public dialog: MatDialog,
      public dialogRef: MatDialogRef<AlertModalecomponenet>, @Inject(MAT_DIALOG_DATA) public data: typeUserConnect,private router:Router)
      {
      }
  
    onNoClick(typeConnect): void {
      if(typeConnect!='login'){
        if(this.data.typeConnect=='Questions')
        {
          this.openQuestion();
        }else if(this.data.typeConnect=='News')
        {
          this.openNew();
        }else{
          this.openReclamation();
        }
      }else{
        this.router.navigate(['/Login']);
      }
      this.dialogRef.close();
    }
    openQuestion(): void {  
    const dialogRef = this.dialog.open(QuestionModalecomponenet, {
      width: '100%',
      panelClass: 'custom-modalbox',
      data: {questionText: this.Question.questionText, 
        questionType: this.Question.questionType, 
        responses: this.Question.responses, 
      }
      
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(result);
      this.Question.questionText = result;
    });
  }
  
  openNew(): void {  
    const dialogRef = this.dialog.open(NewsModalecomponenet, {
      width: '100%',
      panelClass: 'custom-modalbox',
      data: {NewsText: this.News.newsText,  
        commantaires: this.News.commantaires, 
      }
      
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(result);
      this.News.newsText = result;
    });
  }

  openReclamation(): void {  
    const dialogRef = this.dialog.open(ReclamationModalecomponenet, {
      width: '100%',
      panelClass: 'custom-modalbox',
      data: {ReclamationText: this.Reclamation.ReclamationText, 
        commantaires: this.Reclamation.commantaires, 
      }
      
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(result);
      this.Reclamation.ReclamationText = result;
    });
  }
  }