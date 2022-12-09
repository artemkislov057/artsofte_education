import { moduleMetadata } from '@storybook/angular';
import { CommonModule } from '@angular/common';
import { CourseslistComponent } from './courseslist.component';
import { CourseslistModule } from './courseslist.module';
import type { Story, Meta } from '@storybook/angular';


export default {
  title: 'Components/CoursesList',
  component: CourseslistComponent,
  decorators: [
    moduleMetadata({
      imports: [CommonModule, CourseslistModule],
    }),
  ],
  parameters: {
    // More on Story layout: https://storybook.js.org/docs/angular/configure/story-layout
    // layout: 'fullscreen',
  },
} as Meta;

const Template: Story<CourseslistComponent> = (args: CourseslistComponent) => ({
  props: args,
});

export const CoursesList = Template.bind({});
CoursesList.args = {
  
};