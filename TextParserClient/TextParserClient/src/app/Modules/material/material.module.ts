import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MatFormFieldModule} from '@angular/material/form-field';
import { MatInputModule } from '@angular/material';
import { MatButtonModule } from '@angular/material/button';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';


const MAT_MODULS = [
  MatFormFieldModule,
  MatInputModule,
  MatButtonModule,
  MatPaginatorModule,
  MatSortModule,
  MatTableModule
];

@NgModule({
  imports: [
    CommonModule,
    MAT_MODULS
  ],
  declarations: [],
  exports: [MAT_MODULS]
})
export class MaterialModule { }
