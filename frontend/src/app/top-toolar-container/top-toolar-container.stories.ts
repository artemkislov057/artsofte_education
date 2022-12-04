import { moduleMetadata } from '@storybook/angular';
import { CommonModule } from '@angular/common';
import type { Story, Meta } from '@storybook/angular';
import { TopToolarContainerComponent } from './top-toolar-container.component';


export default {
  title: 'Components/TopToolbar',
  component: TopToolarContainerComponent,
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

const Template: Story<TopToolarContainerComponent> = (args: TopToolarContainerComponent) => ({
  props: args,
});

export const TopToolbar = Template.bind({});
TopToolbar.storyName = 'Тулбар';
