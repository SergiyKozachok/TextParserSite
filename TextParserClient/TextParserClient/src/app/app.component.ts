import { Component, ViewChild, OnInit } from '@angular/core';
import { SentencesService } from './Services/sentences.service';
import { MatPaginator, MatSort, PageEvent } from '@angular/material';
import { PaginationService } from './Services/pagination.service';
import { SendSentencesModel } from './Models/SendSentencesModel';

export const DEFAULT_AMOUNT_OF_PATIENTS_ON_PAGE = 15;

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  displayedColumns = ['word', 'sentence', 'quantity', 'dateOfAdded'];
  text = '';
  fileText: string | ArrayBuffer;
  copiedText: string;
  dataSource: string[] = [];
  amountOfSentences = 0;
  sendData: SendSentencesModel = {
    word: '',
    sentences: [],
    quantity: [],
  };

  @ViewChild(MatPaginator) paginator: MatPaginator;

  sentences: Array<string> = [];
  counter: Array<number> = [];

  constructor(private service: SentencesService,
              private pagService: PaginationService) { }

  // tslint:disable-next-line:use-life-cycle-interface
  ngOnInit() {
    this.service.getAllSenteces()
      .subscribe((result: any) => {
        this.dataSource = result.sentences;
        this.amountOfSentences = result.quantity;
      });
  }

  onSubmit() {
    this.sentences = this.convertToArray(this.fileText);
    this.checkConteinWord(this.text, this.sentences);
    this.sendData.word = this.text;
    this.sendData.sentences = this.sentences;
    if (this.sendData.sentences.length != 0) {
      this.numberOfInclusions(this.sendData.sentences, this.sendData.word, this.sendData.quantity);
      this.service.postTest(this.sendData).subscribe();
      window.location.reload();
      this.onClear();
    } else {
      alert('There is no word in the text');
      this.onClear();
    }
  }

  pageSwitch(event: PageEvent) {
    this.pagService.change(event);
    this.service.httpOptions.params = this.service.httpOptions.params.set('page', this.pagService.pageIndex.toString());
    this.service.getAllSenteces()
      .subscribe((result: any) => {
        this.dataSource = result.sentences;
        this.amountOfSentences = result.quantity;
      });
    window.scroll(0, 0);
  }

  fileUpload(event) {
    const reader = new FileReader();
    reader.readAsText(event.srcElement.files[0]);
    reader.onload = (e) => {
      this.fileText = reader.result;
      this.sentences = this.convertToArray(this.fileText);
    };
  }

  convertToArray(str): Array<string> {
    const result = str.match(/[^\.!\?]+[\.!\?]+/g);
    return result;
  }

  checkConteinWord(word: string, arr: Array<string>): Array<string> {
    this.sentences = [];
    arr.forEach(element => {
      if (element.includes(' ' + word + ' ')) {
        this.sentences.push(element);
      }
    });
    return this.sentences;
  }

  numberOfInclusions(arr: Array<string>, str: string, counter: Array<number>) {
    let count = 0;
    arr.forEach(element => {
      // tslint:disable-next-line:no-unused-expression
      count = element.split(' ' + str + ' ').length - 1;
      counter.push(count);
      count = 0;
    });
    return counter;
  }

  onClear() {
    this.text = '';
    this.sendData.word = '';
    this.sendData.sentences = [];
    this.sendData.quantity = [];
  }
}
