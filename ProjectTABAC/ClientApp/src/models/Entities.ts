export interface RouteInfo {
  path: string;
  title: string;
  rtlTitle: string;
  icon: string;
  class: string;
}
export class typeUserConnect {
  typeConnect: string; 
}


export class User{ 
        userId:number=  0;
        firstName: string='';
        lastName: string='';
        email: string='';
        password: string='';
        userType: number=  0;
        mobile: string='';
        commantaires: Commantaire[];
        news: News[];
        responses: Response[]
      }
export class Question{
    questionId: number= 0;
    questionText: string='';
    questionType: number= 0;
    userId: string='';
    responses: Response[]
  }
export class Response{
    responseId: number= 0;
    responseText: string='';
    userId: string='';
    questionId: string='';
    question: Question;
    user: User
  }
export class News{
    newsId: number= 0;
    newsText: string='';
    userId: number= 0;
    user: User;
    commantaires: Commantaire[]
  }
export class Commantaire{
    commantaireId: number= 0;
    commantaireText: string='';
    userId: string='';
    newsId: string='';
    news: News;
    user: User
  }
export class Reclamation{
     ReclamationId: number= 0;
     ReclamationText: string='';
    userId: string='';  
    user: User;
    commantaires: Commantaire[]
  }

  
   