import { moduleMetadata } from '@storybook/angular';
import { CommonModule } from '@angular/common';
import type { Story, Meta } from '@storybook/angular';
import { TestContainerComponent } from './test-container.component';
import { TestContainerModule } from './test-container.module';


export default {
  title: 'Components/TestContainer',
  component: TestContainerComponent,
  decorators: [
    moduleMetadata({
      imports: [CommonModule, TestContainerModule],
    }),
  ],
  parameters: {
    // More on Story layout: https://storybook.js.org/docs/angular/configure/story-layout
    // layout: 'fullscreen',
  },
} as Meta;

const Template: Story<TestContainerComponent> = (args: TestContainerComponent) => ({
  props: args,
});

export const TestContainer = Template.bind({});
TestContainer.storyName = 'default';
