import { moduleMetadata } from '@storybook/angular';
import { CommonModule } from '@angular/common';
import type { Story, Meta } from '@storybook/angular';
import { LessonTypeComponent } from './lesson-type.component';


export default {
  title: 'Components/LessonType',
  component: LessonTypeComponent,
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

const Template: Story<LessonTypeComponent> = (args: LessonTypeComponent) => ({
  props: args,
});

export const LessonTypeText = Template.bind({});
LessonTypeText.args = {
    type: 'text'
}
LessonTypeText.storyName = 'Текст';

export const LessonTypeLiterature = Template.bind({});
LessonTypeLiterature.args = {
    type: 'literature'
}
LessonTypeLiterature.storyName = 'Литература';

export const LessonTypePresentation = Template.bind({});
LessonTypePresentation.args = {
    type: 'presentation'
}
LessonTypePresentation.storyName = 'Презентация';

export const LessonTypeTest = Template.bind({});
LessonTypeTest.args = {
    type: 'test'
}
LessonTypeTest.storyName = 'Тест';

export const LessonTypeVideo = Template.bind({});
LessonTypeVideo.args = {
    type: 'video'
}
LessonTypeVideo.storyName = 'Видео';
