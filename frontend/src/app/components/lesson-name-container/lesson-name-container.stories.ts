import { moduleMetadata } from '@storybook/angular';
import { CommonModule } from '@angular/common';
import type { Story, Meta } from '@storybook/angular';
import { LessonNameContainerComponent } from './lesson-name-container.component';

export default {
  title: 'Components/LessonNameContainer',
  component: LessonNameContainerComponent,
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

const Template: Story<LessonNameContainerComponent> = (args: LessonNameContainerComponent) => ({
  props: args,
});

export const LessonNameContainer = Template.bind({});
LessonNameContainer.args = {
    
}
LessonNameContainer.storyName = 'default';
