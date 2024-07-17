import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppLayoutComponent} from "./layout/app.layout.component";
import {NotFoundComponent} from "./Components/not-found/not-found.component"
import {OperationClaimComponent} from "./Components/operation-claim/operation-claim.component";
import {authGuard} from "./guards/common/auth.guard";

const routes: Routes = [
  {path: '', component: AppLayoutComponent,
    children : [
      {path: 'comp', loadChildren: () => import('./Components/components.module').then(m => m.ComponentsModule)}
    ], canActivate: [authGuard]},


  { path: 'auth', loadChildren: () => import('./auth/auth.module').then(m => m.AuthModule) },
  { path: 'notfound', component: NotFoundComponent },
  { path: '**', redirectTo: '/notfound' },

];

@NgModule({
  imports: [RouterModule.forRoot(
    routes,
    { scrollPositionRestoration: 'enabled', anchorScrolling: 'enabled', onSameUrlNavigation: 'reload' }
  )],
  exports: [RouterModule]
})
export class AppRoutingModule { }
