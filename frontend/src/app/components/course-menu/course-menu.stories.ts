import { moduleMetadata } from '@storybook/angular';
import { CommonModule } from '@angular/common';
import type { Story, Meta } from '@storybook/angular';
import { CourseMenuComponent } from './course-menu.component';
import { CourseMenuModule } from './course-menu.module';


export default {
  title: 'Components/CourseMenu',
  component: CourseMenuComponent,
  decorators: [
    moduleMetadata({
      imports: [CommonModule, CourseMenuModule],
    }),
  ],
  parameters: {
    // More on Story layout: https://storybook.js.org/docs/angular/configure/story-layout
    layout: 'fullscreen',
  },
} as Meta;

const Template: Story<CourseMenuComponent> = (args: CourseMenuComponent) => ({
  props: args,
});

export const CourseMenu = Template.bind({});
CourseMenu.args = {
  
};

