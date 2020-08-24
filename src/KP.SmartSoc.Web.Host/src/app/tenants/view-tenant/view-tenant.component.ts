import {
    Component,
    Injector,
    OnInit,
    Output,
    EventEmitter
} from '@angular/core';
import { finalize } from 'rxjs/operators';
import { AppComponentBase } from '@shared/app-component-base';
import {
    TenantServiceProxy,
    TenantDto
} from '@shared/service-proxies/service-proxies';

@Component({
    selector:'view-tenant',
    templateUrl: 'view-tenant.component.html'
})
export class ViewTenantComponent extends AppComponentBase
    implements OnInit {
    tenant: TenantDto = new TenantDto();
    id: number;
    constructor(
        injector: Injector,
        public _tenantService: TenantServiceProxy,
    ) {
        super(injector);
    }

    ngOnInit(): void {
        console.log("TenantId");
        console.log(this.appSession.tenantId);
        this._tenantService.get(this.appSession.tenantId).subscribe((result: TenantDto) => {
            this.tenant = result;
        });
    }
}
