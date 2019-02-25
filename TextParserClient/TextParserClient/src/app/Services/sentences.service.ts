import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { HOST_URL } from '../config';
import { PaginationService } from './pagination.service';
import { SendSentencesModel } from '../Models/SendSentencesModel';

@Injectable({
  providedIn: 'root'
})
export class SentencesService {
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    }),
    params: new HttpParams()
      .set('pagecount', this.pagService.pageSize.toString())
  };

  constructor(private http: HttpClient,
              private pagService: PaginationService) { }

  postTest(model: SendSentencesModel) {
    const url = HOST_URL + '/api/sentences/addsentences';
    const body = JSON.stringify(model);
    console.log(model);
    return this.http.post(url, body, this.httpOptions);
  }

  getAllSenteces() {
    const url = HOST_URL + '/api/sentences/allsentences';
    return this.http.get(url, this.httpOptions);
  }
}
