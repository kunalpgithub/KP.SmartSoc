import { Component, Injector, ViewChild } from "@angular/core";
import {
  SocietyServiceProxy,
  SocietyDto,
  SocietyListDto,
  ListResultDto,
  PagedRequestDto
} from "shared/service-proxies/service";
import { appModuleAnimation } from "@shared/animation/routerTransmission";
import { PagedListingComponentBase } from "shared/PagedListingComponentBase";
@Component({
  templateUrl: "./Societies.component.html",
  animations: [appModuleAnimation],
})
export class SocietiesComponent extends PagedListingComponentBase<SocietyDto> {
  societies: SocietyListDto[]=[];

  // @ViewChild('createSocietyModal') createSocietyModal: CreateSocietyComponent;
  
  constructor(
    injector: Injector,
    private _societyService: SocietyServiceProxy
  ) {
    super(injector);
  }

  protected list(request:PagedRequestDto,pageNumber: number,finishedCallback:Function){
    this.loadSociety();
    finishedCallback();
  }

  loadSociety(){
    this._societyService.getList()
      .subscribe((result: ListResultDto<SocietyListDto> )=>{
        this.societies =result.items;
      });
  }

  // //Show Modals
  // createEvent():void{
  //   this.createSocietyModal.show();
  // }
}
