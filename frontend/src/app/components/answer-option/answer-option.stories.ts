import { moduleMetadata } from '@storybook/angular';
import { CommonModule } from '@angular/common';
import type { Story, Meta } from '@storybook/angular';
import { AnswerOptionComponent } from './answer-option.component';


export default {
  title: 'Components/AnswerOption',
  component: AnswerOptionComponent,
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

const Template: Story<AnswerOptionComponent> = (args: AnswerOptionComponent) => ({
  props: args,
});

export const RadioOption = Template.bind({});
RadioOption.storyName = 'возможен один правильный ответ';
