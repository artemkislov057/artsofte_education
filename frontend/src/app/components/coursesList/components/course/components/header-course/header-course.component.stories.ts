import { moduleMetadata } from '@storybook/angular';
import { CommonModule } from '@angular/common';
import type { Story, Meta } from '@storybook/angular';
import { HeaderCourseComponent } from './header-course.component';


export default {
  title: 'Components/CoursesList',
  component: HeaderCourseComponent,
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

const Template: Story<HeaderCourseComponent> = (args: HeaderCourseComponent) => ({
  props: args,
});

export const Header = Template.bind({});
Header.args = {
  
};