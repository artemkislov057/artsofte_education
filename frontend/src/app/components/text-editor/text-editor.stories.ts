import { moduleMetadata } from '@storybook/angular';
import { CommonModule } from '@angular/common';
import type { Story, Meta } from '@storybook/angular';
import { TextEditorComponent } from './text-editor.component';


export default {
  title: 'Components/TextEditor',
  component: TextEditorComponent,
  decorators: [
    moduleMetadata({
      imports: [CommonModule],
    }),
  ],
  parameters: {
    // More on Story layout: https://storybook.js.org/docs/angular/configure/story-layout
    // layout: 'fullscreen',
  },
} as Meta;

const Template: Story<TextEditorComponent> = (args: TextEditorComponent) => ({
  props: args,
});

export const Editor = Template.bind({});
Editor.storyName = 'default';

export const EditorWithTitle = Template.bind({});
EditorWithTitle.storyName = 'вместе с заголовком';
EditorWithTitle.args = {
  title: 'Дополнительные материалы:'
}