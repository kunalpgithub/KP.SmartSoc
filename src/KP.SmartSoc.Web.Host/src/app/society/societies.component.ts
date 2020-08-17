import { Component, Injector, ViewChild } from "@angular/core";
import {
  SocietyServiceProxy,
  SocietyDto,
  SocietyListDto,
  SocietyListDtoListResultDto,
} from "@shared/service-proxies/service-proxies";
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { PagedListingComponentBase,PagedRequestDto, } from "@shared/paged-listing-component-base";
@Component({
  templateUrl: "./Societies.component.html",
  animations: [appModuleAnimation()],
})
export class SocietiesComponent extends PagedListingComponentBase<SocietyDto> {
  protected delete(entity: SocietyDto): void {
    throw new Error("Method not implemented.");
  }
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
      .subscribe((result: SocietyListDtoListResultDto )=>{
        this.societies =result.items;
      });
  }

  // //Show Modals
  // createEvent():void{
  //   this.createSocietyModal.show();
  // }
}
