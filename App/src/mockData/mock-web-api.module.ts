import { InMemoryWebApiModule } from 'angular-in-memory-web-api';
import { InMemoryAppDbService } from './memory-data-service';
import { NgModule } from '@angular/core';


@NgModule({
    imports: [InMemoryWebApiModule.forRoot(InMemoryAppDbService)],
    exports: [InMemoryWebApiModule]
})
export class MockWebApiModule {
}