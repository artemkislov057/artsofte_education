import { Component, Input, OnInit } from '@angular/core';
//@ts-ignore
import Header from '@editorjs/header';
//@ts-ignore
import List from '@editorjs/list';
//@ts-ignore
import Marker from '@editorjs/marker';
import EditorJS from '@editorjs/editorjs';

@Component({
  selector: 'app-text-editor',
  templateUrl: './text-editor.component.html',
  styleUrls: ['./text-editor.component.scss']
})
export class TextEditorComponent implements OnInit {
  @Input() title: string = '';
  @Input() unicId: string = '';

  editor: any;
  

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
      }
    })
  }

}
