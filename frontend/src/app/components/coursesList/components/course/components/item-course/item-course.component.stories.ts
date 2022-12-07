import { moduleMetadata } from '@storybook/angular';
import { CommonModule } from '@angular/common';
import type { Story, Meta } from '@storybook/angular';
import { ItemCourseComponent } from './item-course.component';


export default {
  title: 'Components/CoursesList',
  component: ItemCourseComponent,
  decorators: [
    moduleMetadata({
      imports: [CommonModule],
    }),
  ],
  parameters: {
    // More on Story layout: https://storybook.js.org/docs/angular/configure/story-layout
    layout: 'fullscreen',
  },
} as Meta;

const Template: Story<ItemCourseComponent> = (args: ItemCourseComponent) => ({
  props: args,
});

export const ItemCourse = Template.bind({});
ItemCourse.args = {
  
};