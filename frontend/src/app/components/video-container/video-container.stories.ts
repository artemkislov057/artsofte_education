import { moduleMetadata } from '@storybook/angular';
import { CommonModule } from '@angular/common';
import type { Story, Meta } from '@storybook/angular';
import { VideoContainerComponent } from './video-container.component';


export default {
  title: 'Components/VideoContainer',
  component: VideoContainerComponent,
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

const Template: Story<VideoContainerComponent> = (args: VideoContainerComponent) => ({
  props: args,
});

export const VideoContainer = Template.bind({});
VideoContainer.storyName = 'default';
