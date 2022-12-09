import { moduleMetadata } from '@storybook/angular';
import { CommonModule } from '@angular/common';
import type { Story, Meta } from '@storybook/angular';
import { ModuleItemComponent } from './module-item.component';


export default {
  title: 'Components/CourseMenu',
  component: ModuleItemComponent,
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

const Template: Story<ModuleItemComponent> = (args: ModuleItemComponent) => ({
  props: args,
});

export const ModuleItem = Template.bind({});
ModuleItem.args = {
  
};

