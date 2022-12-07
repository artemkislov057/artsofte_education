import { moduleMetadata } from '@storybook/angular';
import { CommonModule } from '@angular/common';
import type { Story, Meta } from '@storybook/angular';
import { CreateContainerComponent } from './create-container.component';


export default {
  title: 'Components/CreateContainer',
  component: CreateContainerComponent,
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

const Template: Story<CreateContainerComponent> = (args: CreateContainerComponent) => ({
  props: args,
});

export const CreateCourseContainer = Template.bind({});
CreateCourseContainer.storyName = 'Создание нового курса'
CreateCourseContainer.args = {
    typeContainerName: 'курса'
};

export const CreateModuleContainer = Template.bind({});
CreateModuleContainer.storyName = 'Создание нового модуля'
CreateModuleContainer.args = {
    typeContainerName: 'модуля'
};