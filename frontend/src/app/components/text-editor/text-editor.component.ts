import { Component, EventEmitter, Input, OnInit, Output, SimpleChanges } from '@angular/core';
//@ts-ignore
import Header from '@editorjs/header';
//@ts-ignore
import List from '@editorjs/list';
//@ts-ignore
import Marker from '@editorjs/marker';
import EditorJS, { OutputData } from '@editorjs/editorjs';

const init: OutputData = {
  time: (new Date()).getTime(),
  version: '2.26.4',
  blocks: [{
    type: 'paragraph',
    data: {
      text: '',
    },
    id: 'a'
  }]
}

@Component({
  selector: 'app-text-editor',
  templateUrl: './text-editor.component.html',
  styleUrls: ['./text-editor.component.scss']
})
export class TextEditorComponent implements OnInit {
  @Input() title: string = '';
  @Input() unicId: string = '';
  @Input() initHeight: number = 300;
  @Input() editData: OutputData | null = null;
  @Input() isSingleComponent: boolean = false;
  @Output() onClickSave = new EventEmitter();
  @Input() test = () => {};

  editor: EditorJS | null = null;

  constructor() { }

  ngOnInit() {
    console.log('new editor')
    this.editor = new EditorJS({
      holder: `editor-js ${this.unicId}`,
      tools: {
        header: {
          class: Header,
          inlineToolbar: ['link']
        },
        list: {
          class: List,
          inlineToolbar: ['link', 'bold']
        },
        marker: {
          class: Marker,
          shortcut: 'CMD+SHIFT+M',
        }
      },
      minHeight: this.initHeight,
    });
    this.editor.isReady.then((e) => {
      console.log('ready')
      this.setExistsData(init)
      if(this.editData !== null) {
        console.log('1')
        this.setExistsData(this.editData)
      }
    })
  }

  ngOnChanges(changes: SimpleChanges) {
    if(this.editData !== null) {
      this.editor?.isReady.then(e => {
        if(this.editData !== null) {
          console.log('2')
          this.setExistsData(this.editData)
        }
      })
    }
  }

  async onSave() {
    await this.editor?.isReady
    const resultData = await this.editor?.save();
    if(resultData) {
      return resultData;
    }
    return null;    
  }

  setExistsData(data: OutputData) {
    this.editor?.isReady.then((e) => {
      if(data && this.editor) {
        this.editor.render(data);
      }
    })
  }
}
