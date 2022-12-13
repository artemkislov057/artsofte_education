import { moduleMetadata } from '@storybook/angular';
import { CommonModule } from '@angular/common';
import type { Story, Meta } from '@storybook/angular';
import { PresentationTopToolbarComponent } from './presentation-top-toolbar.component';

export default {
  title: 'Components/PresentationToolbar',
  component: PresentationTopToolbarComponent,
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

const Template: Story<PresentationTopToolbarComponent> = (args: PresentationTopToolbarComponent) => ({
  props: args,
});

export const PresentationToolbar = Template.bind({});
PresentationToolbar.storyName = 'default';
