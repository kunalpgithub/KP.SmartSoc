import { Component, ViewChild, Injector, Output, EventEmitter, ElementRef, OnInit } from '@angular/core';
import { BsModalRef,ModalDirective } from 'ngx-bootstrap/modal';
import { SocietyServiceProxy, ICreateScoietyDto, CreateScoietyDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';
import { finalize } from 'rxjs/operators';

import * as _ from "lodash";
import * as moment from 'moment';

@Component({
    templateUrl: './create-society.component.html'
})
export class CreateSocietyComponent extends AppComponentBase {

    @Output() onSave: EventEmitter<any> = new EventEmitter<any>();

    active: boolean = false;
    saving: boolean = false;
    society: CreateScoietyDto = new CreateScoietyDto();

    constructor(
        injector: Injector,
        private _societyService: SocietyServiceProxy,
        public bsModalRef: BsModalRef
    ) {
        super(injector);
    }

    save(): void {
        this.saving = true;
        const society = new CreateScoietyDto();
        society.init(this.society);
        this._societyService.create(society)
            .pipe(finalize(() => { this.saving = false; }))
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.bsModalRef.hide();
                this.onSave.emit(null);
            });
    }
}