import { Routes } from "@angular/router";  
import { DashboardAcceuilComponent } from "./dashboard-acceuil/dashboard-acceuil.component";
import { LoginComponent } from "./login/login.component";

export const AcceuilRoutes: Routes = [
  { path: "dashboard2", component: DashboardAcceuilComponent },
  { path: "Login", component: LoginComponent },
];
