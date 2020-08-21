import { Component, Injector, ViewChild } from "@angular/core";
import {
    SocietyServiceProxy,
    SocietyDto,
    SocietyDtoPagedResultDto,
} from "@shared/service-proxies/service-proxies";
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { PagedListingComponentBase, PagedRequestDto, } from "@shared/paged-listing-component-base";
import { CreateSocietyComponent } from './create-society/create-society.component';
import { EditSocietyComponent } from './edit-society/edit-society.component'

import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { finalize } from "rxjs/operators";

class PagedSocietiesRequestDto extends PagedRequestDto {
    keyword: string;
}

@Component({
    templateUrl: "./Societies.component.html",
    animations: [appModuleAnimation()],
})
export class SocietiesComponent extends PagedListingComponentBase<SocietyDto> {
    keyword = '';
    societies: SocietyDto[] = [];

    constructor(
        injector: Injector,
        private _societyService: SocietyServiceProxy,
        private _modalService: BsModalService
    ) {
        super(injector);
    }

    protected delete(entity: SocietyDto): void {

        abp.message.confirm(
            "Are you sure want to delete this society",
            undefined,
            (result: boolean) => {
                this._societyService
                    .delete(entity.id)
                    .pipe(
                        finalize(() => {
                            abp.notify.success("Successfully Deleted");
                            this.refresh();
                        })
                    )
                    .subscribe(() => { })
            }
        )

    }

    list(request: PagedSocietiesRequestDto,
        pageNumber: number,
        finishedCallback: Function): void {
        request.keyword = this.keyword;
        this._societyService.getAll(this.keyword, request.skipCount, request.maxResultCount)
            .pipe(
                finalize(() => { finishedCallback(); })
            )
            .subscribe((result: SocietyDtoPagedResultDto) => {
                this.societies = result.items;
                this.showPaging(result, pageNumber);
            });
    }

    //Show Modals
    createSociety(): void {
        this.showCreateOrEditSocietyDialog();
    }

    editSociety(society: SocietyDto): void {
        this.showCreateOrEditSocietyDialog(society.id);
    }

    showCreateOrEditSocietyDialog(id?: string): void {
        let createSocietyDialog: BsModalRef;
        if (!id) {
            createSocietyDialog = this._modalService.show(
                CreateSocietyComponent,
                {
                    class: 'modal-lg',
                }
            );
        }
        else {
            createSocietyDialog = this._modalService.show(
                EditSocietyComponent,
                {
                    class: 'modal-lg',
                    initialState: {
                        id: id
                    }
                }
            );
        }

        createSocietyDialog.content.onSave.subscribe(() => {
            this.refresh();
        });
    }

    refresh(): void {
        this.getDataPage(this.pageNumber);
    }
}
