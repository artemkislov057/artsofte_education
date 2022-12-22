import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
//@ts-ignore
import Header from '@editorjs/header';
//@ts-ignore
import List from '@editorjs/list';
//@ts-ignore
import Marker from '@editorjs/marker';
import EditorJS, { OutputData } from '@editorjs/editorjs';

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
  @Output() onClickSave = new EventEmitter();
  @Input() test = () => {};

  editor: EditorJS | null = null;
  

  constructor() { }

  ngOnInit(): void {
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
    })
    if(this.editData) {
      // this.editor.render({})
    }
  }

  async onSave() {
    const resultData = await this.editor?.save();
    if(resultData) {
      return resultData;
    }
    return null;    
  }

}
