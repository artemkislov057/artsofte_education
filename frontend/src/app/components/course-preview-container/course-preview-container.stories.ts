import { moduleMetadata } from '@storybook/angular';
import { CommonModule } from '@angular/common';
import type { Story, Meta } from '@storybook/angular';
import { CoursePreviewContainerComponent } from './course-preview-container.component';


export default {
  title: 'Components/CoursePreview',
  component: CoursePreviewContainerComponent,
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

const Template: Story<CoursePreviewContainerComponent> = (args: CoursePreviewContainerComponent) => ({
  props: args,
});

export const CoursePreviewJs = Template.bind({});
CoursePreviewJs.args = {
    title: 'Курс по JavaScript',
    caption: 'Курс для учеников ИРИТ-РТФ',
    srcCourseImage: 'assets/image/jsIcon.svg',
    theme: 'light',
    backgroundColor: ' #F7DF1E'
}
CoursePreviewJs.storyName = 'Превью курса JS';

export const CoursePreviewNet = Template.bind({});
CoursePreviewNet.args = {
    title: 'Курс по .NET',
    caption: 'Курс для учеников ИРИТ-РТФ',
    srcCourseImage: 'assets/image/netIcon.svg',
    theme: 'dark',
    backgroundColor: '#512BD4',
}
CoursePreviewNet.storyName = 'Превью курса .net';

