import { moduleMetadata } from '@storybook/angular';
import { CommonModule } from '@angular/common';
import type { Story, Meta } from '@storybook/angular';
import { CourseComponent } from './course.component';
import { CourseModule } from './course.module';


export default {
  title: 'Components/CoursesList',
  component: CourseComponent,
  decorators: [
    moduleMetadata({
      imports: [CommonModule, CourseModule],
    }),
  ],
  parameters: {
    // More on Story layout: https://storybook.js.org/docs/angular/configure/story-layout
    // layout: 'fullscreen',
  },
} as Meta;

const Template: Story<CourseComponent> = (args: CourseComponent) => ({
  props: args,
});

export const Course = Template.bind({});
Course.args = {
  
};