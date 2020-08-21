import { Component, ViewChild, Injector, Output, EventEmitter, ElementRef, OnInit } from '@angular/core';
import { BsModalRef, ModalDirective } from 'ngx-bootstrap/modal';
import { SocietyServiceProxy, ICreateScoietyDto, CreateScoietyDto, SocietyDto  } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';
import { finalize } from 'rxjs/operators';

import * as _ from "lodash";
import * as moment from 'moment';

@Component({
    templateUrl: './edit-society.component.html'
})
export class EditSocietyComponent extends AppComponentBase implements OnInit {
    id: string;
    @Output() onSave: EventEmitter<any> = new EventEmitter<any>();

    active: boolean = false;
    saving: boolean = false;
    society: SocietyDto = new SocietyDto();

    constructor(
        injector: Injector,
        private _societyService: SocietyServiceProxy,
        public bsModalRef: BsModalRef
    ) {
        super(injector);
    }
    ngOnInit(): void {
        this._societyService.get(this.id).subscribe((result: SocietyDto) => {
            this.society = result;

        })
    }

    save(): void {
        this.saving = true;
        const society = new SocietyDto();
        society.init(this.society);
        this._societyService.update(society)
            .pipe(finalize(() => { this.saving = false; }))
            .subscribe(() => {
                this.notify.info(this.l('Saved Successfully'));
                this.bsModalRef.hide();
                this.onSave.emit(null);
            });
    }
}