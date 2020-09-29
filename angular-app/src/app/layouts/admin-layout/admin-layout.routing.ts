import { LoginComponent } from "./../../login/login.component";
import { LoansComponent } from "./../../pages/loans/loans.component";
import { SavingsComponent } from "./../../pages/savings/savings.component";
import { InvestmentComponent } from "./../../pages/investment/investment.component";
import { SpentComponent } from "./../../pages/spent/spent.component";
import { BanksComponent } from "../../pages/banks/banks.component";
import { Routes } from "@angular/router";
import { DashboardComponent } from "../../pages/dashboard/dashboard.component";
import { IconsComponent } from "../../pages/icons/icons.component";
import { MapComponent } from "../../pages/map/map.component";
import { NotificationsComponent } from "../../pages/notifications/notifications.component";
import { UserComponent } from "../../pages/user/user.component";
import { TablesComponent } from "../../pages/tables/tables.component";
import { TypographyComponent } from "../../pages/typography/typography.component";
import { AngularFireAuthGuard } from "@angular/fire/auth-guard";
import { AuthGuardService } from "src/app/Services/AuthGuard/auth-guard.service";
// import { RtlComponent } from "../../pages/rtl/rtl.component";

export const AdminLayoutRoutes: Routes = [
  {
    path: "dashboard",
    component: DashboardComponent,
    canActivate: [AuthGuardService],
  },
  { path: "icons", component: IconsComponent, canActivate: [AuthGuardService] },
  { path: "maps", component: MapComponent, canActivate: [AuthGuardService] },
  {
    path: "notifications",
    component: NotificationsComponent,
    canActivate: [AuthGuardService],
  },
  { path: "user", component: UserComponent, canActivate: [AuthGuardService] },
  {
    path: "tables",
    component: TablesComponent,
    canActivate: [AuthGuardService],
  },
  {
    path: "typography",
    component: TypographyComponent,
    canActivate: [AuthGuardService],
  },
  { path: "banks", component: BanksComponent, canActivate: [AuthGuardService] },
  { path: "spent", component: SpentComponent, canActivate: [AuthGuardService] },
  {
    path: "investment",
    component: InvestmentComponent,
    canActivate: [AuthGuardService],
  },
  {
    path: "savings",
    component: SavingsComponent,
    canActivate: [AuthGuardService],
  },
  { path: "loans", component: LoansComponent, canActivate: [AuthGuardService] },
  // { path: "rtl", component: RtlComponent }
];
