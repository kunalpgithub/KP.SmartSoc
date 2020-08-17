import { Component, OnInit, Injector, Inject } from "@angular/core";
import {appModuleAnimation } from '@shared/animations/routerTransition';
import {AppComponentBase} from '@shared/app-component-base';
import {SocietyDto,SocietyServiceProxy} from "@shared/service-proxies/service-proxies";
import {ActivatedRoute,Params,Router} from '@angular/router';
import { result } from "lodash";

@Component({
    templateUrl:'./society-detail.component.html',
    animations:[appModuleAnimation()]
})

export class SocietyDetailComponent extends AppComponentBase implements OnInit{

    society: SocietyDto = new SocietyDto();
    societyId:string;

    constructor(
        injector:Injector,
        private _societyService : SocietyServiceProxy,
        private _router:Router,
        private _activatedRoute:ActivatedRoute
    ){
        super(injector)
    }

    ngOnInit():void{
        this._activatedRoute.params.subscribe((params:Params)=>{
            this.societyId = params['societyId'];
            this.loadSociety();
        });
    }

    loadSociety(){
        this._societyService.get(this.societyId)
        .subscribe((result:SocietyDto)=>{
            this.society = result;
        });
    }

    backToSocietiesPage(){
        this._router.navigate(['app/societies']);
    }
}