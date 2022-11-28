import { moduleMetadata } from '@storybook/angular';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from 'src/app/header/header.component'; 
import type { Story, Meta } from '@storybook/angular';


export default {
  title: 'Example/Header',
  component: HeaderComponent,
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

const Template: Story<HeaderComponent> = (args: HeaderComponent) => ({
  props: args,
});

export const DefaultHeader = Template.bind({});
DefaultHeader.args = {
  
};

