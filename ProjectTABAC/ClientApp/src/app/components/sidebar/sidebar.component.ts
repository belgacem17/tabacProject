import { Component, OnInit } from "@angular/core";
import { UserServicesService } from "src/app/services/userServices/user-services.service";

declare interface RouteInfo {
  path: string;
  title: string;
  rtlTitle: string;
  icon: string;
  class: string;
}
export let  ROUTES: RouteInfo[] = [
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

@Component({
  selector: "app-sidebar",
  templateUrl: "./sidebar.component.html",
  styleUrls: ["./sidebar.component.css"]
})
export class SidebarComponent implements OnInit {
  menuItems: any[];
  color:any={}
  constructor(private userServicesService : UserServicesService) {

    ROUTES=this.userServicesService.RouterUser;
    if(ROUTES==null)
    {
      ROUTES=JSON.parse(localStorage.getItem('router'));
    }
  }

  ngOnInit() {
    this.menuItems = ROUTES.filter(menuItem => menuItem);
  }
  isMobileMenu() {
    if (window.innerWidth > 991) {
      return false;
    }
    return true;
  }
  
}
