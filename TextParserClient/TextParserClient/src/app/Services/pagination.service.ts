import { Injectable } from '@angular/core';
import { Pagination } from '../Models/PaginationModel';
import { PageEvent } from '@angular/material';

@Injectable({
  providedIn: 'root'
})
export class PaginationService {
  private paginationModel: Pagination;

  get pageIndex(): number {
    return this.paginationModel.pageIndex;
  }
  set pageIndex(num: number) {
    this.paginationModel.pageIndex = num;
  }
  get pageSize(): number {
    return this.paginationModel.pageSize;
  }
  get userPageSize(): number {
    return this.paginationModel.userPageSize;
  }
  get feedbackPageSize(): number {
    return this.paginationModel.feedbackPageSize;
  }

  constructor() {
    this.paginationModel = new Pagination();
  }

  change(pageEvent: PageEvent) {
    this.paginationModel.pageIndex = pageEvent.pageIndex + 1;
    this.paginationModel.pageSize = pageEvent.pageSize;
    this.paginationModel.feedbackPageSize = pageEvent.pageSize;
    this.paginationModel.allItemsLength = pageEvent.length;
  }
}
