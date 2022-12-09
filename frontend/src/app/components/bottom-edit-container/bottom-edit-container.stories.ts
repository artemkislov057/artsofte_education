import { moduleMetadata } from '@storybook/angular';
import { CommonModule } from '@angular/common';
import type { Story, Meta } from '@storybook/angular';
import { BottomEditContainerComponent } from './bottom-edit-container.component';


export default {
  title: 'Components/BottomEditButtons',
  component: BottomEditContainerComponent,
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

const Template: Story<BottomEditContainerComponent> = (args: BottomEditContainerComponent) => ({
  props: args,
});

export const BottomEditButtons = Template.bind({});
BottomEditButtons.args = {
    
}
BottomEditButtons.storyName = 'default';
