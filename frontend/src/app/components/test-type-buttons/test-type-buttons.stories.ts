import { moduleMetadata } from '@storybook/angular';
import { CommonModule } from '@angular/common';
import type { Story, Meta } from '@storybook/angular';
import { TestTypeButtonsComponent } from './test-type-buttons.component';


export default {
  title: 'Components/TestTypeButtons',
  component: TestTypeButtonsComponent,
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

const Template: Story<TestTypeButtonsComponent> = (args: TestTypeButtonsComponent) => ({
  props: args,
});

export const OneType = Template.bind({});
OneType.storyName = 'возможен один правильный ответ';

export const FewType = Template.bind({});
FewType.storyName = 'возможно несколько правильных ответ';
FewType.args = {
    isActiveRadio: false,
}
