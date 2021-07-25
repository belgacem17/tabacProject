import { Component, OnInit } from '@angular/core';
import { UserServicesService } from "src/app/services/userServices/user-services.service";
import { Router } from '@angular/router';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  email: string = '';
  password:any;
  constructor(public userServicesService : UserServicesService,private router:Router) { 
console.log('sdqdqs')
    let connect=localStorage.getItem('user');
    if(connect!=null)
    {
      this.router.navigate(['/dashboard']);
    }
  }

  ngOnInit(): void {
  }

  connectUser()
  {
   
    this.userServicesService.ConnectUser(this.email,this.password).subscribe((result) => {
   
      if((result.userType!=1)&&(result.userType!=2))
      {
        this.userServicesService.RouterUser=[
          {
            path: "/dashboard",
            title: "Dashboard",
            rtlTitle: "لوحة القيادة",
            icon: "icon-chart-pie-36",
            class: ""
          },
          
          {
            path: "/user",
            title: "User Profile",
            rtlTitle: "ملف تعريفي للمستخدم",
            icon: "icon-mobile",
            class: ""
          },
          {
            path: "/news",
            title: "News",
            rtlTitle: "News",
            icon: "icon-minimal-down",
            class: ""
          },
          {
            path: "/questions",
            title: "Questions",
            rtlTitle: "Questions",
            icon: "icon-light-3",
            class: ""
          },
          {
            path: "/reclamations",
            title: "Reclamation",
            rtlTitle: "Reclamation",
            icon: "icon-badge",
            class: ""
          },
          
        ];
      }else{
        this.userServicesService.RouterUser=[
          {
            path: "/dashboard",
            title: "Dashboard",
            rtlTitle: "لوحة القيادة",
            icon: "icon-chart-pie-36",
            class: ""
          }, 
          {
            path: "/news",
            title: "News",
            rtlTitle: "News",
            icon: "icon-minimal-down",
            class: ""
          },
          {
            path: "/questions",
            title: "Questions",
            rtlTitle: "Questions",
            icon: "icon-light-3",
            class: ""
          },
          {
            path: "/reclamations",
            title: "Reclamation",
            rtlTitle: "Reclamation",
            icon: "icon-badge",
            class: ""
          },
          
        ];
      }
      localStorage.setItem('router',JSON.stringify(this.userServicesService.RouterUser))
      localStorage.setItem('user',JSON.stringify(result))
      this.router.navigate(['/dashboard']);
    }); 
  }
}
