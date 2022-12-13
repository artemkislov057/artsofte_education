import { moduleMetadata } from '@storybook/angular';
import { CommonModule } from '@angular/common';
import type { Story, Meta } from '@storybook/angular';
import { PresentationContainerComponent } from './presentation-container.component';
import { PresentationContainerModule } from './presentation-container.module';

export default {
  title: 'Components/PresentationContainer',
  component: PresentationContainerComponent,
  decorators: [
    moduleMetadata({
      imports: [CommonModule, PresentationContainerModule],
    }),
  ],
  parameters: {
    // More on Story layout: https://storybook.js.org/docs/angular/configure/story-layout
    // layout: 'fullscreen',
  },
} as Meta;

const Template: Story<PresentationContainerComponent> = (args: PresentationContainerComponent) => ({
  props: args,
});

export const PresentationContainer = Template.bind({});

PresentationContainer.storyName = 'default';
